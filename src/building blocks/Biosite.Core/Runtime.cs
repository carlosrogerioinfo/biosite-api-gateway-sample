namespace Biosite.Core
{
    public static class Runtime
    {
        public static string ConnectionString = "Server=biosite.mssql.somee.com;Database=biosite;User ID=carlospereira_SQLLogin_1;Password=48kabd7zri;";
        public static string JwtSecretKey = "T`XN;|OL'T_.-cr5151t3Vfztyi[sHle}6eCE]F>Ek]o/-5727-6450244d15-b787-c6bbbb-ZU2o!>+Y~=D;%Y;ox3/=(_M=x0S";
        public static string Audience = "https://homolog-apix.Biosite.com/";
        public static string Issuer = "https://homolog-apix.Biosite.com/";
        public static int ExpiresInMinutes = 120;
    }
}