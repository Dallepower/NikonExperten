using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepoNE;
using System.Data.SqlClient;
namespace RepoNE
{
    public class BrugerFac : AutoFac<Bruger>
    {
        Mapper<Bruger> mapper = new Mapper<Bruger>();
        public Bruger Login(string email, string password)
        {

            using (var CMD = new SqlCommand("SELECT * FROM Bruger WHERE Email=@Email AND Adgangskode=@Adgangskode", Conn.CreateConnection()))
            {
                CMD.Parameters.AddWithValue("@Email", email.Trim());
                CMD.Parameters.AddWithValue("@Adgangskode", password.Trim());

                var r = CMD.ExecuteReader();
                Bruger per = new Bruger();

                if (r.Read())
                {
                    per = mapper.Map(r);
                }

                r.Close();
                CMD.Connection.Close();

                return per;

            }
        }
    }
}
