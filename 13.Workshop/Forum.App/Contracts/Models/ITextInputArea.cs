public interface ITextInputArea
{
    string Text { get; }

    void Write();

    void Render();
}