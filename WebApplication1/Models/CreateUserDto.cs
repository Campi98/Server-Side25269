public class CreateUserDto
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public string Tipo { get; set; }
    public int? ID_do_Grupo { get; set; }  // Chave estrangeira para Grupo_de_Viagem
}
