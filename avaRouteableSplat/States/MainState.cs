using System.Runtime.Serialization;

namespace avaRouteableSplat.States;

[DataContract]
public class MainState
{

    [DataMember]
    public string SomeData { get; set; } = "default value";

}
