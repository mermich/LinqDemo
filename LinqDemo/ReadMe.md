# Linq : kickstart

Linq est constitue d'une suite de methode d'extentions sur IEnaumerbale qui permet tout un set d'operations sur les listes.
Ces methodes permettent de manipuler bien plus facilement toutes les taches communes sur les listes.

Les 3 exemples les plus communs :
Retrouver un element dans une liste a partir d'un critere
Retrouver tous les elements a partir d'un critere
Trier une liste

Mails il y a aussi d'autres methodes tres utiles : groupby, select, selectMany

Lien pour plus de doc : https://github.com/dotnet/try-samples/blob/main/101-linq-samples/index.md


## Retouver un element
Pour retouver un element suivant un critere, il existe de nombreuses methodes qui ont un fonctionnement proche :
- First
- FirstOrDefault
- Single
- SingleOrDefault

La methode la plus permissive est FirstOrDefault, c'est donc celle que je recommande.

```
private static Student? FindPerfectStudents(List<Student> students)
{
    // Style boucle for:
    foreach (var student in students)
    {
        if (student.Grade== 20)
        {
            return student;
        }
    }

    // Linq :
    return students.FirstOrDefault(s => s.Grade >= 20);
}```
