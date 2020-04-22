using DialogueTrees.Actions;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace DialogueTrees.Builder.Build
{
    internal static partial class Builder
    {
        private static Action BuildActionSingle(XmlElement baseElement)
        {
            List<Action> actions = BuildAction(baseElement);

            if (actions.Count != 1)
                throw new System.Exception("There must only be one action.");

            return actions[0];
        }

        private static List<Action> BuildAction(XmlElement baseElement)
        {
            List<Action> actions = new List<Action>();

            actions.AddRange(
                from e in baseElement.SelectNodes("ExitAction").Cast<XmlElement>()
                select new ExitAction()
            );

            actions.AddRange(
                from e in baseElement.SelectNodes("IfAction").Cast<XmlElement>()
                select new IfAction()
                {
                    propertyReferenceName = (e.SelectSingleNode("PropertyReference") as XmlElement)
                        .GetAttribute("ref:property"),

                    Value = e.GetAttribute("value"),

                    TrueAction = BuildActionSingle(e),
                    FalseAction = BuildActionSingle(e.SelectSingleNode("ElseAction") as XmlElement)
                }
            );

            actions.AddRange(
                from e in baseElement.SelectNodes("OptionsAction").Cast<XmlElement>()
                select new OptionsAction()
                {
                    Options = new List<Option>
                    (
                        from o in e.SelectNodes("Option").Cast<XmlElement>()
                        select BuildOption(o)
                    )
                }
            );

            actions.AddRange(
                from e in baseElement.SelectNodes("RandomAction").Cast<XmlElement>()
                select new RandomAction()
                {
                    Actions = BuildAction(e)
                }
            );

            actions.AddRange(
                from e in baseElement.SelectNodes("ReturnAction").Cast<XmlElement>()
                select new ReturnAction() { Value = e.GetAttribute("value") }
            );

            actions.AddRange(
                from e in baseElement.SelectNodes("ToActionSetAction").Cast<XmlElement>()
                select new ToActionAction()
                {
                    actionReferenceName = (e.SelectSingleNode("ActionSetReference") as XmlElement)
                        .GetAttribute("ref:actions")
                }
            );

            actions.AddRange(
                from e in baseElement.SelectNodes("ToDialogueAction").Cast<XmlElement>()
                select new ToDialogueAction()
                {
                    dialogueReferenceName = (e.SelectSingleNode("DialogueReference") as XmlElement)
                        .GetAttribute("ref:dialogue")
                }
            );

            actions.AddRange(
                from e in baseElement.SelectNodes("ToEntryAction").Cast<XmlElement>()
                select new ToEntryAction()
            );

            return actions;
        }
    }
}