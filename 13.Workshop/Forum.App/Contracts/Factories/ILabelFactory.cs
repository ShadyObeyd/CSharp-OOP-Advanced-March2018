public interface ILabelFactory
{
    ILabel CreateLabel(string content, Position position, bool isHidden = false);

    IButton CreateButton(string content, Position position, bool isHidden = false, bool isField = false);
}