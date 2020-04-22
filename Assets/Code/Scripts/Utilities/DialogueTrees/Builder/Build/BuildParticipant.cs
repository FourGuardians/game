using System.Xml;

namespace DialogueTrees.Builder.Build
{
    internal static partial class Builder
    {
        private static Participant BuildParticipant(XmlElement element) => new Participant()
        {
            Name = element.GetAttribute("name")
        };
    }
}