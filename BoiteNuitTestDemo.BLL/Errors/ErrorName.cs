namespace BoiteNuitTestDemo.BLL.Errors;

// CENTRALISATION DES MESSAGES D'ERREUR
// Tous les messages d'erreur de l'application sont regroupés dans cette classe.
//
// Pourquoi c'est une bonne pratique :
// 1. Une seule source de vérité : le message est écrit à un seul endroit.
//    Pour le modifier, on change une ligne ici et tout le projet suit.
// 2. Pas de faute de frappe : on n'écrit plus le texte à la main dans le service
//    ET dans le test. Une faute dans le nom (ErrorName.EmailAlredyExist) est
//    détectée par le compilateur, alors qu'une faute dans un texte ne l'est pas.
// 3. Des tests plus solides : le service et le test utilisent la même valeur.
//    Si on reformule le message, le test continue de passer sans modification.
// 4. Plus lisible : ErrorName.EmailAlreadyExist dit clairement de quelle erreur
//    il s'agit, mieux qu'un long texte au milieu du code.
// 5. Facile à retrouver : l'autocomplétion (taper "ErrorName.") affiche toutes
//    les erreurs existantes, ce qui évite d'en créer des doublons.
// 6. Messages cohérents : on voit toutes les erreurs ensemble, donc on garde
//    le même style partout. Ça facilitera aussi une traduction plus tard.
public static class ErrorName
{
    public static readonly string EmailAlreadyExist = "Email already exists in database";
    public static readonly string AgeIsUnder16 = "The age of new client is too young because under 16";

    // EXERCICE : ajouter ici le message d'erreur pour l'âge minimum
}