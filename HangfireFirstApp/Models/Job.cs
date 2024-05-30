namespace HangfireFirstApp.Models;
public class Job
{
    public Guid JobId { get; set; }
    public string Modulo { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string Cron { get; set; }
    public int Ordem { get; set; }
    public bool Ativo { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime DataAtualizacao { get; set; }
    public string UsuarioAtualizacao { get; set; }

    protected Job() { }

    public string Tag()
    {
        return $"{Modulo}-{Nome}";
    }
}