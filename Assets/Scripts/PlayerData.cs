using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using System;
using System.Runtime.Serialization;
using System.Reflection;

[Serializable ()]
public class PlayerData : ISerializable {

	private int count;

	private IList<WeaponData> weapons;

	public void bump() {
		count++;
	}

	public IList<WeaponData> GetWeaponData() {
		return weapons;
	}

	public int getCount() {
		return count;
	}

	// default constructor?
	public PlayerData(){
		weapons = new List<WeaponData> ();
	}

	public PlayerData(SerializationInfo info, StreamingContext context) {
		weapons = new List<WeaponData> ();
		
		foreach(SerializationEntry entry in info) {
			switch(entry.Name) {
			case "count":
				count = (int)info.GetValue ("count", typeof(int));
				break;
			case "weaponCount":
				for (int i = 0; i < (int)info.GetValue("weaponCount", typeof(int)); i++){
					WeaponData current = new WeaponData ();
					current.SetCooldown ((int)info.GetValue ("weaponCD_" + i, typeof(int)));
					weapons.Add (current);
				}
				break;
			}
		}
	}

	public void GetObjectData(SerializationInfo info, StreamingContext context) {
		info.AddValue ("count", count);
		info.AddValue ("weaponCount", weapons.Count);
		for (int i = 0; i < weapons.Count; i++) {
			info.AddValue ("weaponCD_" + i, weapons [i].GetCooldown ());
		}
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