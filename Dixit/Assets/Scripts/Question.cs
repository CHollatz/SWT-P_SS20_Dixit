﻿/* created by: SWT-P_SS_20_Dixit */

using UnityEngine;
using System.Threading.Tasks;
using Firebase.Firestore;


/// <summary>
/// Represents a Question in the Game.
/// Communicates with database to retrieve questions.
/// </summary>
/// \author SWT-P_SS_20_Dixit
[FirestoreData]
public class Question
{
    /// <summary>
    /// The Question as string
    /// </summary>
    /// \author SWT-P_SS_20_Dixit
    [FirestoreProperty]
    public string QuestionText { get; set; }

    /// <summary>
    /// The level of difficulty of this question
    /// </summary>
    /// \author SWT-P_SS_20_Dixit
    [FirestoreProperty]
    public int Difficulty { get; set; }

    /// <summary>
    /// An explanation for the correct answer
    /// </summary>
    /// \author SWT-P_SS_20_Dixit
    [FirestoreProperty]
    public string Explanation { get; set; }

    /// <summary>
    /// The correct answer of this question
    /// </summary>
    /// \author SWT-P_SS_20_Dixit
    [FirestoreProperty]
    public string Answer { get; set; }

    /// <summary>
    /// Retrieves question data from the database.
    /// </summary>
    /// <param name="reference">The reference to the question document in the database</param>
    /// <returns>The referenced document as Question Object</returns>
    /// \author SWT-P_SS_20_Dixit
    public static Task<Question> RetrieveQuestion(DocumentReference reference)
    {
        return reference.GetSnapshotAsync().ContinueWith((task) =>
        {
            if (task.IsFaulted)
                throw task.Exception;

            var snapshot = task.Result;
            if (!snapshot.Exists)
            {
                Debug.Log(string.Format("Question document {0} does not exist!", snapshot.Id));
                return null;
            }
            return snapshot.ConvertTo<Question>();
        });
    }
}
