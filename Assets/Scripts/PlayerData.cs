using UnityEngine;
using System.Collections;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using System;
using System.Runtime.Serialization;
using System.Reflection;

[Serializable ()]
public class PlayerData : ISerializable {

	private int count;

	public void bump() {
		count++;
	}

	public int getCount() {
		return count;
	}

	// default constructor?
	public PlayerData(){
	}

	public PlayerData(SerializationInfo info, StreamingContext context) {
		count = (int)info.GetValue ("count", typeof(int));
	}

	public void GetObjectData(SerializationInfo info, StreamingContext context) {
		info.AddValue ("count", count);
	}
}

public class SaveLoad {
	private static string currentFilePath = "save.gg";

	public static void Save(PlayerData data) {
		Stream stream = File.Open (currentFilePath, FileMode.Create);
		BinaryFormatter formatter = new BinaryFormatter ();
		formatter.Binder = new VersionDeserializationBinder ();
		formatter.Serialize (stream, data);
		stream.Close ();
	}

	public static PlayerData Load() {
		Stream stream = File.Open (currentFilePath, FileMode.Open);
		BinaryFormatter formatter = new BinaryFormatter ();
		formatter.Binder = new VersionDeserializationBinder ();
		PlayerData data = (PlayerData)formatter.Deserialize (stream);
		stream.Close ();
		data.bump ();
		return data;
	}
}

// required?
public sealed class VersionDeserializationBinder : SerializationBinder {
	public override Type BindToType(string assemblyName, string typeName) {
		if (!string.IsNullOrEmpty(assemblyName) && !string.IsNullOrEmpty(typeName)) {
			Type typeToDeserialize = null;
			assemblyName = Assembly.GetExecutingAssembly().FullName;

			typeToDeserialize = Type.GetType(typeName+", "+assemblyName);

			return typeToDeserialize;
		}
		return null;
	}
}