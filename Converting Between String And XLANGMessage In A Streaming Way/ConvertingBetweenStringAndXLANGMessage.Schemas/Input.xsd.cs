namespace ConvertingBetweenStringAndXLANGMessage.Schemas {
    using Microsoft.XLANGs.BaseTypes;
    
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [SchemaType(SchemaTypeEnum.Document)]
    [Schema(@"http://ConvertingBetweenStringAndXLANGMessage.Schemas.Input",@"Input")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.Int32), "Value1", XPath = @"/*[local-name()='Input' and namespace-uri()='http://ConvertingBetweenStringAndXLANGMessage.Schemas.Input']/*[local-name()='Value1' and namespace-uri()='']", XsdType = @"int")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.Int32), "Value2", XPath = @"/*[local-name()='Input' and namespace-uri()='http://ConvertingBetweenStringAndXLANGMessage.Schemas.Input']/*[local-name()='Value2' and namespace-uri()='']", XsdType = @"int")]
    [System.SerializableAttribute()]
    [SchemaRoots(new string[] {@"Input"})]
    public sealed class Input : Microsoft.XLANGs.BaseTypes.SchemaBase {
        
        [System.NonSerializedAttribute()]
        private static object _rawSchema;
        
        [System.NonSerializedAttribute()]
        private const string _strSchema = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xs:schema xmlns=""http://ConvertingBetweenStringAndXLANGMessage.Schemas.Input"" xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" targetNamespace=""http://ConvertingBetweenStringAndXLANGMessage.Schemas.Input"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
  <xs:element name=""Input"">
    <xs:annotation>
      <xs:appinfo>
        <b:properties>
          <b:property distinguished=""true"" xpath=""/*[local-name()='Input' and namespace-uri()='http://ConvertingBetweenStringAndXLANGMessage.Schemas.Input']/*[local-name()='Value1' and namespace-uri()='']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='Input' and namespace-uri()='http://ConvertingBetweenStringAndXLANGMessage.Schemas.Input']/*[local-name()='Value2' and namespace-uri()='']"" />
        </b:properties>
      </xs:appinfo>
    </xs:annotation>
    <xs:complexType>
      <xs:sequence>
        <xs:element name=""Value1"" type=""xs:int"" />
        <xs:element name=""Value2"" type=""xs:int"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
</xs:schema>";
        
        public Input() {
        }
        
        public override string XmlContent {
            get {
                return _strSchema;
            }
        }
        
        public override string[] RootNodes {
            get {
                string[] _RootElements = new string [1];
                _RootElements[0] = "Input";
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
