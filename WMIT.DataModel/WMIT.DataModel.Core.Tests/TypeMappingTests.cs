using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WMIT.DataModel.Core.Mapping;
using System.Collections.Generic;

namespace WMIT.DataModel.Core.Tests
{
    [TestClass]
    public class TypeMappingTests
    {
        TypeScriptTypeMapper typeMapper;

        [TestInitialize]
        public void Initialize()
        {
            typeMapper = new TypeScriptTypeMapper();
        }

        #region Primitive Types
        [TestMethod]
        [TestCategory("Primitive types")]
        public void CanGetTypeNamesForPrimitives()
        {
            string typeName = typeMapper.GetTypeName<int>();
            Assert.AreEqual("number", typeName);
        }
        #endregion

        #region Collection types 
        [TestMethod]
        [TestCategory("Collection types")]
        public void CanGetTypeNamesForArrays()
        {
            string typeName = typeMapper.GetTypeName<int[]>();
            Assert.AreEqual("number[]", typeName);
        }

        [TestMethod]
        [TestCategory("Collection types")]
        public void CanGetTypeNamesForGenericLists()
        {
            string typeName = typeMapper.GetTypeName<List<int>>();
            Assert.AreEqual("number[]", typeName);
        }

        [TestMethod]
        [TestCategory("Collection types")]
        public void CanGetTypeNamesForICollections()
        {
            string typeName = typeMapper.GetTypeName<ICollection<int>>();
            Assert.AreEqual("number[]", typeName);
        }

        [TestMethod]
        [TestCategory("Collection types")]
        public void CanGetTypeNamesForNestedArrays()
        {
            string typeName = typeMapper.GetTypeName<int[][]>();
            Assert.AreEqual("number[][]", typeName);
        }

        [TestMethod]
        [TestCategory("Collection types")]
        public void CanGetTypeNamesForNestedListsAndArrays()
        {
            string typeName = typeMapper.GetTypeName<List<float[]>>();
            Assert.AreEqual("number[][]", typeName);
        }
        #endregion

        #region Advanced types 
        [TestMethod]
        [TestCategory("Advanced types")]
        public void CanGetTypeNamesForDateTime()
        {
            string typeName = typeMapper.GetTypeName<DateTime>();
            Assert.AreEqual("Date", typeName);
        }

        [TestMethod]
        [TestCategory("Advanced types")]
        public void CanGetTypeNamesForNullableTypes()
        {
            string typeName = typeMapper.GetTypeName<int?>();
            Assert.AreEqual("number?", typeName);
        }

        public class MyEntityTypeA { }
        [TestMethod]
        [TestCategory("Advanced types")]
        public void CanGetTypeNamesForOtherEntityTypes()
        {
            string typeName = typeMapper.GetTypeName<MyEntityTypeA>();
            Assert.AreEqual("MyEntityTypeA", typeName);
        }
        #endregion
    }
}
