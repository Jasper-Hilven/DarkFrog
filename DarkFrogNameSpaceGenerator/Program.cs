using System;
using System.Collections.Generic;
using System.IO;
using DarkFrogNameSpaceData;
namespace DarkFrogNameSpaceGenerator
{
  class Program
  {
    static void Main(string[] args)
    {
      var root = DarkFrogNameSpaceData.NameSpaceDataBuilder.GetRoot();
      var path = @"C:\Users\Jasper\Desktop\TestGen";
      GenerateHierachyNodeContent(path,root);
    }

    private static void GenerateHierachyNodeContent(string filePath, NameSpaceHierarchyNode node)
    {
      var path = filePath + node.Name;
      var pathSlashed = path + @"\";
      Directory.Delete(path,true);
      Directory.CreateDirectory(path);
      foreach (var nameSpaceHierarchyNode in node.Children)
        GenerateHierachyNodeContent(pathSlashed,nameSpaceHierarchyNode);
      foreach (var nameSpaceHierarchyBareFunction in node.Elements)
        GenerateBareMethodClassFile(nameSpaceHierarchyBareFunction, node, pathSlashed);
    }


    private static void GenerateBareMethodClassFile(NameSpaceHierarchyBareFunction bareFunction,NameSpaceHierarchyNode parent,string parentalPath)
    {
      var res = GenerateClassHeader(bareFunction,parent);
      res.AddRange(GenerateMethodImplementation(bareFunction));
      res.AddRange(GenerateClosingFile());
      var fileName = parentalPath + bareFunction.name + ".cs";
      File.WriteAllLines(fileName,res);
    }

    private static List<string> GenerateClassHeader(NameSpaceHierarchyBareFunction bareFunction, NameSpaceHierarchyNode parent)
    {
      throw new NotImplementedException();
    }

    private static List<string> GenerateMethodImplementation(NameSpaceHierarchyBareFunction bareFunction)
    {
      throw new NotImplementedException();
    }

    private static List<string> GenerateClosingFile()
    {
      throw new NotImplementedException();
    }
  }
}
