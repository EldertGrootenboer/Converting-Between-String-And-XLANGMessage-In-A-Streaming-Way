namespace ConvertingBetweenStringAndXLANGMessage.Schemas {
    using Microsoft.XLANGs.BaseTypes;
    
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [SchemaType(SchemaTypeEnum.Document)]
    [Schema(@"http://ConvertingBetweenStringAndXLANGMessage.Schemas.Input",@"Order")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.Int32), "Price", XPath = @"/*[local-name()='Order' and namespace-uri()='http://ConvertingBetweenStringAndXLANGMessage.Schemas.Input']/*[local-name()='Price' and namespace-uri()='']", XsdType = @"int")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.Int32), "Amount", XPath = @"/*[local-name()='Order' and namespace-uri()='http://ConvertingBetweenStringAndXLANGMessage.Schemas.Input']/*[local-name()='Amount' and namespace-uri()='']", XsdType = @"int")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.Int32), "OrderNumber", XPath = @"/*[local-name()='Order' and namespace-uri()='http://ConvertingBetweenStringAndXLANGMessage.Schemas.Input']/*[local-name()='OrderNumber' and namespace-uri()='']", XsdType = @"int")]
    [System.SerializableAttribute()]
    [SchemaRoots(new string[] {@"Order"})]
    public sealed class Order : Microsoft.XLANGs.BaseTypes.SchemaBase {
        
        [System.NonSerializedAttribute()]
        private static object _rawSchema;
        
        [System.NonSerializedAttribute()]
        private const string _strSchema = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xs:schema xmlns=""http://ConvertingBetweenStringAndXLANGMessage.Schemas.Input"" xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" targetNamespace=""http://ConvertingBetweenStringAndXLANGMessage.Schemas.Input"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
  <xs:element name=""Order"">
    <xs:annotation>
      <xs:appinfo>
        <b:properties>
          <b:property distinguished=""true"" xpath=""/*[local-name()='Order' and namespace-uri()='http://ConvertingBetweenStringAndXLANGMessage.Schemas.Input']/*[local-name()='Price' and namespace-uri()='']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='Order' and namespace-uri()='http://ConvertingBetweenStringAndXLANGMessage.Schemas.Input']/*[local-name()='Amount' and namespace-uri()='']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='Order' and namespace-uri()='http://ConvertingBetweenStringAndXLANGMessage.Schemas.Input']/*[local-name()='OrderNumber' and namespace-uri()='']"" />
        </b:properties>
      </xs:appinfo>
    </xs:annotation>
    <xs:complexType>
      <xs:sequence>
        <xs:element name=""OrderNumber"" type=""xs:int"" />
        <xs:element name=""Customer"" type=""xs:string"" />
        <xs:element name=""Product"" type=""xs:string"" />
        <xs:element name=""Price"" type=""xs:int"" />
        <xs:element name=""Amount"" type=""xs:int"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
</xs:schema>";
        
        public Order() {
        }
        
        public override string XmlContent {
            get {
                return _strSchema;
            }
        }
        
        public override string[] RootNodes {
            get {
                string[] _RootElements = new string [1];
                _RootElements[0] = "Order";
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
