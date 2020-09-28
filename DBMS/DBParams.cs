namespace DBMS
{
    struct DBParams
    {
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
