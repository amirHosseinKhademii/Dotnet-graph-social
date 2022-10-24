namespace hot_demo.interfaces;

public interface IJwtAuthentication {
  string Authenticate (string id,string email);
}