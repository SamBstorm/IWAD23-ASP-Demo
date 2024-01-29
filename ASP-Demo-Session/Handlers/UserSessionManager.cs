
using ASP_Demo_Session.Models;
using System.Text.Json;

namespace ASP_Demo_Session.Handlers
{
    public class UserSessionManager : SessionManager
    {
        public UserSessionManager(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }

        public CurrentUser? CurrentUser     //Permet de récupérer les données sauvgardées en session
        {
            //Deserialize : JSON => C#
            get { return JsonSerializer.Deserialize<CurrentUser>(_session.GetString(nameof(CurrentUser)) ?? "null"); }
        }

        public void LogUser(CurrentUser user)   //Permet de sauvegarder les données de l'utilisateur dans la session
        {
            if(user is null) throw new ArgumentNullException(nameof(user),"L'utilisateur est null");
            if (!(_session.GetString(nameof(CurrentUser)) is null)) throw new InvalidOperationException("Un utilisateur est déjà connecté");
            //Serialize : C# => JSON
            _session.SetString(nameof(CurrentUser),JsonSerializer.Serialize(user));
        }

        public void DisconnectUser()   //Permet de supprimer les données de l'utilisateur dans la session
        {
            if (_session.GetString(nameof(CurrentUser)) is null) throw new InvalidOperationException("Aucun utilisateur n'est connecté.");
            _session.Remove(nameof(CurrentUser));
        }
    }
}
