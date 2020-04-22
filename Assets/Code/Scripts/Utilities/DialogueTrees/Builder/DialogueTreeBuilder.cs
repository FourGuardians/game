using System.Xml;
using UnityEngine;

namespace DialogueTrees.Builder
{
    public static class DialogueTreeBuilder
    {
        public static DialogueTree FromText(TextAsset file)
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(file.text);
            
            string version = 
            (
                document.SelectSingleNode("processing-instruction('dialogue-tree')")
                as XmlProcessingInstruction
            ).Value;

            if (version != "1.0")
                throw new System.Exception("Can only parse dialogue tree version 1.0!");

            return Link.Linker.LinkDialogueTree(
                Build.Builder.BuildDialogueTree(
                    document.SelectSingleNode("//document/DialogueTree") as XmlElement
                )
            );
        }
    }
}