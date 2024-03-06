namespace Bookkeeper_API.Model.Services
{
    public class UnixTimestampConverter
    {
        public static int DateTimeToUnixTimestamp(DateTime dateTime)
        {
            // This code was written with the help of ChatGPT
            // https://chat.openai.com/share/17d57246-e4c5-4eae-a532-ea700c6b6925

            DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan timeSpan = dateTime - unixEpoch;
            return (int)timeSpan.TotalSeconds;
        }
    }
}
