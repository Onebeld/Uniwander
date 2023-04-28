using Array = Godot.Collections.Array;

[Tool]
public partial class PlanetMeshFace : MeshInstance3D
{
	[Export]
	public Vector3 Normal;
	
	public void RegenerateMesh(Resource? planetData)
	{
		if (planetData is null)
			return;
		
		Array arrays = new();
		arrays.Resize((int)Mesh.ArrayType.Max);

		int resolution = (int)planetData.Get("resolution");
		int numVertices = resolution * resolution;
		int numIndices = (resolution - 1) * (resolution - 1) * 6;

		Vector3[] normalArray = new Vector3[numVertices];
		Vector2[] uvArray = new Vector2[numVertices];
		Vector3[] vertexArray = new Vector3[numVertices];
		int[] indexArray = new int[numIndices];

		int triIndex = 0;

		Vector3 axisA = new(Normal.Y, Normal.Z, Normal.X);
		Vector3 axisB = Normal.Cross(axisA);

		for (int y = 0; y < resolution; y++)
		{
			for (int x = 0; x < resolution; x++)
			{
				int i = x + y * resolution;
				Vector2 percent = new Vector2(x, y) / (resolution - 1);
				Vector3 pointOnUnitCube = Normal + (percent.X - 0.5f) * 2.0f * axisA + (percent.Y - 0.5f) * 2.0f * axisB;
				Vector3 pointOnUnitSphere = pointOnUnitCube.Normalized();
				Vector3 pointOnPlanet = (Vector3)planetData.Call("point_on_planet", pointOnUnitSphere);
				vertexArray[i] = pointOnPlanet;

				float length = pointOnPlanet.Length();
				
				if (length < (float)planetData.Get("min_height"))
					planetData.Set("min_height", length);
				if (length > (float)planetData.Get("max_height"))
					planetData.Set("max_height", length);

				if (x != resolution - 1 && y != resolution - 1)
				{
					indexArray[triIndex + 2] = i;
					indexArray[triIndex + 1] = i + resolution + 1;
					indexArray[triIndex] = i + resolution;

					indexArray[triIndex + 5] = i;
					indexArray[triIndex + 4] = i + 1;
					indexArray[triIndex + 3] = i + resolution + 1;

					triIndex += 6;
				}
			}
		}

		for (int a = 0; a < indexArray.Length; a += 3)
		{
			int b = a + 1;
			int c = a + 2;
			
			Vector3 ab = vertexArray[indexArray[b]] - vertexArray[indexArray[a]];
			Vector3 bc = vertexArray[indexArray[c]] - vertexArray[indexArray[b]];
			Vector3 ca = vertexArray[indexArray[a]] - vertexArray[indexArray[c]];

			Vector3 crossAbBc = ab.Cross(bc) * -1.0f;
			Vector3 crossBcCa = bc.Cross(ca) * -1.0f;
			Vector3 crossCaAb = ca.Cross(ab) * -1.0f;

			normalArray[indexArray[a]] += crossAbBc + crossBcCa + crossCaAb;
			normalArray[indexArray[b]] += crossAbBc + crossBcCa + crossCaAb;
			normalArray[indexArray[c]] += crossAbBc + crossBcCa + crossCaAb;
		}

		for (int i = 0; i < normalArray.Length; i++)
			normalArray[i] = normalArray[i].Normalized();

		arrays[(int)Mesh.ArrayType.Vertex] = vertexArray;
		arrays[(int)Mesh.ArrayType.Normal] = normalArray;
		arrays[(int)Mesh.ArrayType.TexUV] = uvArray;
		arrays[(int)Mesh.ArrayType.Index] = indexArray;
		
		UpdateMesh(arrays, planetData);
	}

	private void UpdateMesh(Array arrays, Resource planetData)
	{
		ArrayMesh mesh = new();
		mesh.AddSurfaceFromArrays(Mesh.PrimitiveType.Triangles, arrays);
		
		Mesh = mesh;
		
		((ShaderMaterial)MaterialOverride).SetShaderParameter("min_height", (float)planetData.Get("min_height"));
		((ShaderMaterial)MaterialOverride).SetShaderParameter("max_height", (float)planetData.Get("max_height"));
		((ShaderMaterial)MaterialOverride).SetShaderParameter("height_color", (GradientTexture2D)planetData.Get("planet_color"));
	}
}
