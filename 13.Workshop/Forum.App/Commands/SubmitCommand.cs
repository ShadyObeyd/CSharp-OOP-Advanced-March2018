using System;

public class SubmitCommand : ICommand
{
    private ISession session;
    private IPostService postService;

    public SubmitCommand(ISession session, IPostService postService)
    {
        this.session = session;
        this.postService = postService;
    }
    
    public IMenu Execute(params string[] args)
    {
        string replyContent = args[0];

        if (string.IsNullOrWhiteSpace(replyContent))
        {
            throw new ArgumentException("Reply content cannot be empty or white space!");
        }

        int postId = int.Parse(args[1]);
        int authorId = this.session.UserId;

        this.postService.AddReplyToPost(postId, replyContent, authorId);

        return this.session.Back();
    }
}