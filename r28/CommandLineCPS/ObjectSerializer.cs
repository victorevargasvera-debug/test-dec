// Decompiled with JetBrains decompiler
// Type: MackinawCPS.CommandLineCPS.ObjectSerializer
// Assembly: APXFamilyCPS, Version=15.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 7983BD42-76AB-479D-8966-B7B635E0E28A
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyDepot R28\APXdepotR28.exe

using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

#nullable disable
namespace MackinawCPS.CommandLineCPS;

public static class ObjectSerializer
{
  internal static byte[] Serialize(object instance)
  {
    Trace.WriteLine("[ObjectSerializer][Information][Begin][Serialize]");
    MemoryStream serializationStream = new MemoryStream();
    new BinaryFormatter().Serialize((Stream) serializationStream, instance);
    byte[] array = serializationStream.ToArray();
    Trace.WriteLine("[ObjectSerializer][Information][End][Serialize]");
    return array;
  }

  internal static T Deserialize<T>(byte[] array)
  {
    Trace.WriteLine("[ObjectSerializer][Information][Begin][Deserialize]");
    MemoryStream serializationStream = (MemoryStream) null;
    try
    {
      serializationStream = new MemoryStream(array);
      return (T) new BinaryFormatter().Deserialize((Stream) serializationStream);
    }
    finally
    {
      serializationStream?.Close();
      Trace.WriteLine("[ObjectSerializer][Information][End][Deserialize]");
    }
  }

  internal static void SerializeToFile(string filePath, object instance)
  {
    Trace.WriteLine("[ObjectSerializer][Information][Begin][SerializeToFile]");
    BinaryFormatter binaryFormatter = new BinaryFormatter();
    Stream serializationStream = (Stream) new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
    serializationStream.SetLength(0L);
    binaryFormatter.Serialize(serializationStream, instance);
    serializationStream.Close();
    Trace.WriteLine("[ObjectSerializer][Information][End][SerializeToFile]");
  }

  internal static T DeserializeFromFile<T>(string filePath)
  {
    Trace.WriteLine("[ObjectSerializer][Information][Begin][DeserializeFromFile]");
    Stream serializationStream = (Stream) null;
    try
    {
      serializationStream = (Stream) new FileStream(filePath, FileMode.Open, FileAccess.Read);
      return (T) new BinaryFormatter().Deserialize(serializationStream);
    }
    finally
    {
      serializationStream?.Close();
      Trace.WriteLine("[ObjectSerializer][Information][End][DeserializeFromFile]");
    }
  }

  internal static byte[] XmlSerialize(object instance)
  {
    Trace.WriteLine("[ObjectSerializer][Information][Begin][XmlSerialize]");
    XmlSerializer xmlSerializer = new XmlSerializer(instance.GetType());
    MemoryStream memoryStream = new MemoryStream();
    xmlSerializer.Serialize((Stream) memoryStream, instance);
    byte[] array = memoryStream.ToArray();
    memoryStream.Close();
    Trace.WriteLine("[ObjectSerializer][Information][End][XmlSerialize]");
    return array;
  }

  internal static T XmlDeserialize<T>(byte[] array)
  {
    Trace.WriteLine("[ObjectSerializer][Information][Begin][XmlDeserialize]");
    MemoryStream memoryStream = (MemoryStream) null;
    try
    {
      memoryStream = new MemoryStream(array);
      return (T) new XmlSerializer(typeof (T)).Deserialize((Stream) memoryStream);
    }
    finally
    {
      memoryStream?.Close();
      Trace.WriteLine("[ObjectSerializer][Information][End][XmlDeserialize]");
    }
  }

  internal static void XmlSerializeToFile(string xmlFilePath, object instance)
  {
    Trace.WriteLine("[ObjectSerializer][Information][Begin][XmlSerializeToFile]");
    XmlSerializer xmlSerializer = new XmlSerializer(instance.GetType());
    Stream stream = (Stream) new FileStream(xmlFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
    stream.SetLength(0L);
    xmlSerializer.Serialize(stream, instance);
    stream.Close();
    Trace.WriteLine("[ObjectSerializer][Information][End][XmlSerializeToFile]");
  }

  internal static T XmlDeserializeFromFile<T>(string xmlFilePath)
  {
    Trace.WriteLine("[ObjectSerializer][Information][Begin][XmlDeserializeFromFile]");
    Stream stream = (Stream) null;
    try
    {
      XmlSerializer xmlSerializer = new XmlSerializer(typeof (T));
      stream = (Stream) new FileStream(xmlFilePath, FileMode.Open, FileAccess.Read);
      return (T) xmlSerializer.Deserialize(stream);
    }
    finally
    {
      stream?.Close();
      Trace.WriteLine("[ObjectSerializer][Information][End][XmlDeserializeFromFile]");
    }
  }

  public static T DataContract_DeserializeFromFile<T>(string filePath)
  {
    Stream stream = (Stream) null;
    try
    {
      stream = (Stream) new FileStream(filePath, FileMode.Open, FileAccess.Read);
      return (T) new DataContractSerializer(typeof (T)).ReadObject(stream);
    }
    finally
    {
      stream?.Close();
    }
  }

  public static void DataContract_SerializeToFile(string filePath, object instance)
  {
    DataContractSerializer contractSerializer = new DataContractSerializer(instance.GetType());
    using (Stream stream = (Stream) new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
    {
      stream.SetLength(0L);
      contractSerializer.WriteObject(stream, instance);
    }
  }
}
