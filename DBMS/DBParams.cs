namespace DBMS
{
    struct DBParams
    {
        public DBParams(string serverName, string dBName, string dBFileName, string dBFilePath, string logFileName, string logFilePath, string userId, string password)
        {
            ServerName = serverName;
            DBName = dBName;
            DBFileName = dBFileName;
            DBFilePath = dBFilePath;
            LogFileName = logFileName;
            LogFilePath = logFilePath;
            UserId = userId;
            Password = password;
        }

        public string ServerName { get; set; }
        public string DBName { get; set; }
        public string DBFileName { get; set; }
        public string DBFilePath { get; set; }
        public string LogFileName { get; set; }
        public string LogFilePath { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}
