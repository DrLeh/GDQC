using AngleSharp;
using GDQC.Contracts;

namespace GDQC.Core
{

    public class ScheduleService : IScheduleService
    {
        public async Task<ScheduleView> GetScheduleAsync()
        {
            var config = Configuration.Default.WithDefaultLoader();
            var address = "https://gamesdonequick.com/schedule";
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(address);
            var rowSelector = "table tbody tr";
            var rows = document.QuerySelectorAll(rowSelector);

            var sched = new ScheduleView();
            ScheduleGameView currentGame = new();
            sched.Games.Add(currentGame);
            foreach (var row in rows)
            {
                if (row is null)
                    continue;

                var className = row.ClassName ?? "";
                if (className.Contains("day-split"))
                {
                    //ignore
                }
                else if (className.Contains("second-row"))
                {
                    var secondRowContent = row.Children[0].TextContent.Trim();
                    TimeSpan.TryParse(secondRowContent, out var time);
                    currentGame.Estimate = time;
                    currentGame.Category = row.Children[1].TextContent;
                    currentGame.Host = row.Children[2].TextContent;

                    currentGame = new();
                    sched.Games.Add(currentGame);
                }
                else
                {
                    //first row
                    var startTime = row.Children[0].TextContent;
                    currentGame.StartTime = DateTime.Parse(startTime).ToUniversalTime();
                    currentGame.Game = row.Children[1].TextContent;
                    currentGame.Runner = row.Children[2].TextContent;
                    var setupText = row.Children[3].TextContent;
                    if (!string.IsNullOrWhiteSpace(setupText))
                        currentGame.SetupLength = TimeSpan.Parse(setupText);
                }
            }

            sched.Games.Remove(sched.Games.Last());

            var now = DateTime.UtcNow;
            var current = sched.Games.Where(x => x.StartTime < now)
                .OrderByDescending(x => x.StartTime)
                .First();
            current.IsCurrent = true;

            return sched;
        }
    }
}