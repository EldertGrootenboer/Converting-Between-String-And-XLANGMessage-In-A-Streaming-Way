namespace ConvertingBetweenStringAndXLANGMessage.Schemas {
    using Microsoft.XLANGs.BaseTypes;
    
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [SchemaType(SchemaTypeEnum.Document)]
    [Schema(@"http://ConvertingBetweenStringAndXLANGMessage.Schemas.Routing",@"Routing")]
    [Microsoft.XLANGs.BaseTypes.PropertyAttribute(typeof(global::ConvertingBetweenStringAndXLANGMessage.Schemas.PropertySchema.Target), XPath = @"/*[local-name()='Routing' and namespace-uri()='http://ConvertingBetweenStringAndXLANGMessage.Schemas.Routing']/*[local-name()='Target' and namespace-uri()='']", XsdType = @"string")]
    [System.SerializableAttribute()]
    [SchemaRoots(new string[] {@"Routing"})]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"ConvertingBetweenStringAndXLANGMessage.Schemas.PropertySchema.PropertySchema", typeof(global::ConvertingBetweenStringAndXLANGMessage.Schemas.PropertySchema.PropertySchema))]
    public sealed class Routing : Microsoft.XLANGs.BaseTypes.SchemaBase {
        
        [System.NonSerializedAttribute()]
        private static object _rawSchema;
        
        [System.NonSerializedAttribute()]
        private const string _strSchema = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xs:schema xmlns=""http://ConvertingBetweenStringAndXLANGMessage.Schemas.Routing"" xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" xmlns:ns0=""https://ConvertingBetweenStringAndXLANGMessage.Schemas.PropertySchema"" targetNamespace=""http://ConvertingBetweenStringAndXLANGMessage.Schemas.Routing"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
  <xs:annotation>
    <xs:appinfo>
      <b:imports>
        <b:namespace prefix=""ns0"" uri=""https://ConvertingBetweenStringAndXLANGMessage.Schemas.PropertySchema"" location=""ConvertingBetweenStringAndXLANGMessage.Schemas.PropertySchema.PropertySchema"" />
      </b:imports>
    </xs:appinfo>
  </xs:annotation>
  <xs:element name=""Routing"">
    <xs:annotation>
      <xs:appinfo>
        <b:properties>
          <b:property name=""ns0:Target"" xpath=""/*[local-name()='Routing' and namespace-uri()='http://ConvertingBetweenStringAndXLANGMessage.Schemas.Routing']/*[local-name()='Target' and namespace-uri()='']"" />
        </b:properties>
      </xs:appinfo>
    </xs:annotation>
    <xs:complexType>
      <xs:sequence>
        <xs:element name=""Target"" type=""xs:string"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
</xs:schema>";
        
        public Routing() {
        }
        
        public override string XmlContent {
            get {
                return _strSchema;
            }
        }
        
        public override string[] RootNodes {
            get {
                string[] _RootElements = new string [1];
                _RootElements[0] = "Routing";
                return _RootElements;
            }
        }
        
        protected override object RawSchema {
            get {
                return _rawSchema;
            }
            set {
                _rawSchema = value;
            }
        }
    }
}
