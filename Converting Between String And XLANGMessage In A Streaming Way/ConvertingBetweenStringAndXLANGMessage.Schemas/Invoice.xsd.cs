namespace ConvertingBetweenStringAndXLANGMessage.Schemas {
    using Microsoft.XLANGs.BaseTypes;
    
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [SchemaType(SchemaTypeEnum.Document)]
    [Schema(@"http://ConvertingBetweenStringAndXLANGMessage.Schemas.Invoice",@"Invoice")]
    [System.SerializableAttribute()]
    [SchemaRoots(new string[] {@"Invoice"})]
    public sealed class Invoice : Microsoft.XLANGs.BaseTypes.SchemaBase {
        
        [System.NonSerializedAttribute()]
        private static object _rawSchema;
        
        [System.NonSerializedAttribute()]
        private const string _strSchema = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xs:schema xmlns=""http://ConvertingBetweenStringAndXLANGMessage.Schemas.Invoice"" xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" targetNamespace=""http://ConvertingBetweenStringAndXLANGMessage.Schemas.Invoice"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
  <xs:element name=""Invoice"">
    <xs:complexType>
      <xs:sequence>
        <xs:element name=""OrderNumber"" type=""xs:string"" />
        <xs:element name=""TotalCost"" type=""xs:int"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
</xs:schema>";
        
        public Invoice() {
        }
        
        public override string XmlContent {
            get {
                return _strSchema;
            }
        }
        
        public override string[] RootNodes {
            get {
                string[] _RootElements = new string [1];
                _RootElements[0] = "Invoice";
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
