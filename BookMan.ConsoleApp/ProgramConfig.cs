namespace BookMan.ConsoleApp
{
    using Models;
    using Controllers;
    using DataServices;
    using Framework;

    internal partial class Program
    {
        private static void ConfigRouter()
        {
            //IDataAccess context = new BinaryDataAccess();
            IDataAccess context = Config.Instance.IDataAccess;

            BookController controller = new BookController(context);
            ShellController shell = new ShellController(context);
            ConfigController config = new ConfigController();

            Router r = Router.Instance;

            r.Register("about", About);
            r.Register("help", Help);
            r.Register(route: "create",
                action: p => controller.Create(),
                help: "[create]\r\nnhập sách mới");
            r.Register(route: "do create",
                action: p => controller.Create(toBook(p)),
                help: "this router should be used only in code");
            r.Register(route: "update",
                action: p => controller.Update(p["id"].ToInt()),
                help: "[update ? id = <value>]\r\ntìm và cập nhật sách");
            r.Register(route: "do update",
                action: p => controller.Update(p["id"].ToInt(), toBook(p)),
                help: "this route should be used only in code");
            r.Register(route: "delete",
                action: p => controller.Delete(p["id"].ToInt()),
                help: "[delete ? id = <value>");
            r.Register(route: "do delete",
                action: p => controller.Delete(p["id"].ToInt(), true),
                help: "this route should be used only in code");
            r.Register(route: "single",
                action: p => controller.Single(p["id"].ToInt()),
                help: "[single ? id = <value>]\r\nhiển thị một cuốn sách theo id");
            r.Register(route: "single file",
                action: p => controller.Single(p["id"].ToInt(), p["path"]),
                help: "[single gile ? id = <value> & path = <value>]");
            r.Register(route: "list",
               action: p => controller.List(),
               help: "[list]\r\nhiển thị tất cả sách");
            r.Register(route: "list file",
                action: p => controller.List(p["path"]),
                help: "[list file ? path = <value>]\r\nhiển thị tất cả sách");
            r.Register(route: "filter",
                action: p => controller.Filter(p["key"]),
                help: "[filter ? key = <value>]\r\nTìm sách theo từ khóa");
            r.Register(route: "add shell",
                action: p => shell.Shell(p["path"], p["ext"]),
                help: "[add shell ? path = <value>");
            r.Register(route: "read",
                action: p => shell.Read(p["id"].ToInt()),
                help: "[read ? id = <value>]");
            r.Register(route: "mark",
                action: p => controller.Mark(p["id"].ToInt()),
                help: "[mark ? id = <value>]");
            r.Register(route: "unmark",
                action: p => controller.Mark(p["id"].ToInt(), false),
                help: "[unmark ? id = <value>]");
            r.Register(route: "show marks",
                action: p => controller.ShowMarks(),
                help: "[show marks]");
            r.Register(route: "clear",
                action: p => shell.Clear(),
                help: "[clear]\r\nUse with care");
            r.Register(route: "do clear",
                action: p => shell.Clear(true),
                help: "[clear]\r\nUse with care");
            r.Register("save shell",
                p => shell.Save(),
                "[save shell]");
            r.Register(route: "show stats",
                action: p => controller.Stats(),
                help: "[show stats]");
            r.Register(route: "config prompt text",
                action: p => config.ConfigPromptText(p["text"]),
                help: "[config prompt text ? text = <value>");
            r.Register(route: "config prompt color",
                action: p => config.ConfigPromptColor(p["color"]),
                help: "[config prompt color ? color = <value>");
            r.Register(route: "current data access",
                action: p => config.CurrentDataAccess(),
                help: "[current data access");
            r.Register(route: "config data access",
                action: p => config.ConfigDataAccess(p["da"], p["file"]),
                help: "[config data access ? da = <value: json, binary,xml> & file = <value>");            
        }
        #region helper
        public static Book toBook(Parameter p)
        {
            var b = new Book();
            if (p.ContainsKey("id")) b.Id = p["id"].ToInt();
            if (p.ContainsKey("authours")) b.Authors = p["authours"];
            if (p.ContainsKey("title")) b.Title = p["title"];
            if (p.ContainsKey("publisher")) b.Publisher = p["publisher"];
            if (p.ContainsKey("year")) b.Year = p["year"].ToInt();
            if (p.ContainsKey("edition")) b.Edition = p["edition"].ToInt();
            if (p.ContainsKey("isbn")) b.Isbn = p["isbn"];
            if (p.ContainsKey("tags")) b.Tags = p["tags"];
            if (p.ContainsKey("description")) b.Description = p["description"];
            if (p.ContainsKey("file")) b.File = p["file"];
            if (p.ContainsKey("rate")) b.Rating = p["rate"].ToInt();
            if (p.ContainsKey("reading")) b.Reading = p["reading"].ToBool();
            return b;
        }
        #endregion
    }
}