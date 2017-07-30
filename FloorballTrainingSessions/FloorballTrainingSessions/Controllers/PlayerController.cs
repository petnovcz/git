using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace FloorballTrainingSessions.Models
{
    [Authorize]
    public class PlayerController : Controller
    {
        protected PlayersController c = new PlayersController();
        protected AspNetUsersController a = new AspNetUsersController();
        protected SeasonsController s = new SeasonsController();
        protected TeamPlayersController tp = new TeamPlayersController();
        protected TeamsController t = new TeamsController();
        protected TrainingExcersisesController te = new TrainingExcersisesController();

        public PlayerModel Main(int? SeasonId, int? TeamId)
        {
            PlayerModel p = new PlayerModel();
            p.CurrentUser = a.AspNetUserByID(User.Identity.GetUserId());
            p.CurrentPlayer = c.GetPlayerbyUserID(p.CurrentUser.Id);
            p.ActiveSeason = s.GetActiveSeason();
            if (SeasonId != null) { p.ActiveSeason = s.GetSeasonByID(SeasonId.Value); };
            p.CurrentPlayerTeams = tp.GetTeamsForPlayerandSeason(p.CurrentPlayer.Id, p.ActiveSeason.Id,true,null);
            p.Seasons = s.GetSeason(p.CurrentPlayer.Id,true,null);
            if (TeamId != null) { p.ActiveTeam = t.GetTeamById(TeamId.Value); }
            if (TeamId == null) { p.ActiveTeam = t.GetTeamById(p.CurrentPlayerTeams.FirstOrDefault().Teams.Id); }
            
                return p;

        }
        public static String FONT = "resources/fonts/FreeSans.ttf";
        public FileStreamResult trainingtopdf()
        {
            MemoryStream workStream = new MemoryStream();
            Document document = new Document();
            PdfWriter.GetInstance(document, workStream).CloseStream = false;

            document.Open();
            Font f1 = FontFactory.GetFont(FONT, "Cp1250", true);
            document.Add(new Paragraph("Hello World"));
            document.Add(new Paragraph(DateTime.Now.ToString()));
            document.Add(new Paragraph(te.ListForTrainingPdf(29)));
            document.Add(new Paragraph("Testing of letters Č,Ć,Š,Ž,Đ", new Font(Font.FontFamily.HELVETICA, 10)));
            document.Close();

            byte[] byteInfo = workStream.ToArray();
            workStream.Write(byteInfo, 0, byteInfo.Length);
            workStream.Position = 0;

            return new FileStreamResult(workStream, "application/pdf");
        }

        

        // GET: Player
        public ActionResult Index(int? SeasonId, int? TeamId)
        {
            PlayerModel p = new PlayerModel();
            p = Main(SeasonId,TeamId);

            return View(p);
        }
    }

}