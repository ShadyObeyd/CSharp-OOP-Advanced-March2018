public class WriteCommand : ICommand
{
    private ISession session;

    public WriteCommand(ISession session)
    {
        this.session = session;
    }

    public IMenu Execute(params string[] args)
    {
        ITextAreaMenu textAreaMenu = (ITextAreaMenu)this.session.CurrentMenu;
        textAreaMenu.TextArea.Write();

        return textAreaMenu;
    }
}