﻿using Database;
using UnityEngine;

public class DBTest : MonoBehaviour
{
    //QuestRepository questRepository = new QuestRepository();
    void Start()
    {
        
        QuestStageDB stageDB = new QuestStageDB();
        QuestObjectDB questDB = new QuestObjectDB();


        int[,] nextStages = new int[2, 2] { { 12, 2 }, { 13, 3 } };
        QuestStage stage = new QuestStage(1, nextStages, "Stufe 1");
        stageDB.AddData(stage);

        questDB.AddData(new Quest(21, "TestQuest1", "In Progress", stage, stage, false));


        nextStages = new int[1, 2] { { 16, 8 } };
        stage = new QuestStage(6, nextStages, "Quest 2 Stage 1");
        stageDB.AddData(stage);

        questDB.AddData(new Quest(22, "TestQuest2", "In Progress", stage, stage, false));


        nextStages = new int[1, 2] { { 17, 9 } };
        stage = new QuestStage(7, nextStages, "Quest 3 Stage 1");
        stageDB.AddData(stage);

        questDB.AddData(new Quest(23, "TestQuest3", "In Progress", stage, stage, false));


        nextStages = new int[1, 2] { { 14, 4 } };
        stage = new QuestStage(2, nextStages, "Stufe 2 Decision 1");
        stageDB.AddData(stage);

        nextStages = new int[1, 2] { { 15, 5 } };
        stage = new QuestStage(3, nextStages, "Stufe 2 Decision 2");
        stageDB.AddData(stage);

        nextStages = new int[1, 2] { { -1, -1 } };
        stage = new QuestStage(4, nextStages, "Finished Quest with Decision 1");
        stageDB.AddData(stage);

        nextStages = new int[1, 2] { { -1, -1 } };
        stage = new QuestStage(5, nextStages, "Finished Quest with Decision 2");
        stageDB.AddData(stage);

        nextStages = new int[1, 2] { { -1, -1 } };
        stage = new QuestStage(8, nextStages, "Quest 2 Stage 2");
        stageDB.AddData(stage);

        nextStages = new int[1, 2] { { -1, -1 } };
        stage = new QuestStage(9, nextStages, "Quest 3 Stage 2");
        stageDB.AddData(stage);

        stageDB.close();
        questDB.close();

        DialogueLineDB dialogueLineDB1 = new DialogueLineDB();

        dialogueLineDB1.AddData(new DialogueLine(1, "Hallo!", 2));
        dialogueLineDB1.AddData(new DialogueLine(2, "Ich bin ein Stein!", 3));
        dialogueLineDB1.AddData(new DialogueLine(3, "Schnauze, Stein!", 4));
        dialogueLineDB1.AddData(new DialogueLine(4, "Hallo Roboter!", 5));
        dialogueLineDB1.AddData(new DialogueLine(5, "Erzähl mir was!", 10));
        dialogueLineDB1.AddData(new DialogueLine(6, "Ich bin kein Roboter, ich bin ein Stein!", 6));
        dialogueLineDB1.AddData(new DialogueLine(7, "Sorry!", 8));
        dialogueLineDB1.AddData(new DialogueLine(8, "Ich bestehe auf Roboter.", 7));
        dialogueLineDB1.AddData(new DialogueLine(9, "Dann unterhalt dich halt mit dir selbst!", 4));
        dialogueLineDB1.AddData(new DialogueLine(10, "Ist ok...", 9));
        dialogueLineDB1.AddData(new DialogueLine(11, "Möchtest du was interessantes wissen?", 15));
        dialogueLineDB1.AddData(new DialogueLine(12, "Nein", 4));
        dialogueLineDB1.AddData(new DialogueLine(13, "Ja", 10));
        dialogueLineDB1.AddData(new DialogueLine(14, "Was willst du hören?", 11));
        dialogueLineDB1.AddData(new DialogueLine(15, "Einen Witz bitte.", 12));
        dialogueLineDB1.AddData(new DialogueLine(16, "Was cooles!", 13));
        dialogueLineDB1.AddData(new DialogueLine(17, "Etwas, das ich wieder vergessen will.", 14));
        dialogueLineDB1.AddData(new DialogueLine(18, "Deine Mutter!", 4));
        dialogueLineDB1.AddData(new DialogueLine(19, "Wer eine nukleare Explosion verursacht, wird in Deutschland mit einer Freiheitsstrafe bis zu fünf Jahren oder mit einer Geldstrafe bestraft.", 4));
        dialogueLineDB1.AddData(new DialogueLine(20, "Bei Giraffen uriniert das Weibchen vor der Paarung in den Mund des Männchens.", 4));
        
        dialogueLineDB1.close();


        DialogueObjectDB dialogueObjectDB1 = new DialogueObjectDB();

        int[] array1 = { 1 };
        dialogueObjectDB1.AddData(new DialogueObject(1, "Line", array1));
        int[] array2 = { 2 };
        dialogueObjectDB1.AddData(new DialogueObject(2, "Line", array2));
        int[] array3 = { 3, 4, 5 };
        dialogueObjectDB1.AddData(new DialogueObject(3, "Decision", array3));
        int[] array4 = { 0 };
        dialogueObjectDB1.AddData(new DialogueObject(4, "End", array4));
        int[] array5 = { 6 };
        dialogueObjectDB1.AddData(new DialogueObject(5, "Line", array5));
        int[] array6 = { 7, 8 };
        dialogueObjectDB1.AddData(new DialogueObject(6, "Decision", array6));
        int[] array7 = { 9 };
        dialogueObjectDB1.AddData(new DialogueObject(7, "Line", array7));
        int[] array8 = { 10 };
        dialogueObjectDB1.AddData(new DialogueObject(8, "Line", array8));
        int[] array9 = { 11 };
        dialogueObjectDB1.AddData(new DialogueObject(9, "Line", array9));
        int[] array10 = { 14 };
        dialogueObjectDB1.AddData(new DialogueObject(10, "Line", array10));
        int[] array11 = { 15, 16, 17 };
        dialogueObjectDB1.AddData(new DialogueObject(11, "Decision", array11));
        int[] array12 = { 18 };
        dialogueObjectDB1.AddData(new DialogueObject(12, "Line", array12));
        int[] array13 = { 19 };
        dialogueObjectDB1.AddData(new DialogueObject(13, "Line", array13));
        int[] array14 = { 20 };
        dialogueObjectDB1.AddData(new DialogueObject(14, "Line", array14));
        int[] array15 = { 12, 13 };
        dialogueObjectDB1.AddData(new DialogueObject(15, "Decision", array15));
 
        dialogueObjectDB1.close();
        
        DialogueClipDb dialogueClipDb = new DialogueClipDb();

        const string dialogueSteinPath = "Dialogue/Stein/";
        dialogueClipDb.AddData(new DialogClip($"{dialogueSteinPath}stein-hallo", 1, 1));
        dialogueClipDb.AddData(new DialogClip($"{dialogueSteinPath}stein-ich-bin", 2, 2));
        dialogueClipDb.AddData(new DialogClip($"{dialogueSteinPath}stein-roboter", 6, 6));
        dialogueClipDb.AddData(new DialogClip($"{dialogueSteinPath}stein-unterhalte", 9, 9));
        dialogueClipDb.AddData(new DialogClip($"{dialogueSteinPath}stein-okay", 10, 10));
        dialogueClipDb.AddData(new DialogClip($"{dialogueSteinPath}stein-interessant", 11, 11));
        dialogueClipDb.AddData(new DialogClip($"{dialogueSteinPath}stein-hören", 14, 14));
        dialogueClipDb.AddData(new DialogClip($"{dialogueSteinPath}stein-mutter", 18, 18));
        dialogueClipDb.AddData(new DialogClip($"{dialogueSteinPath}stein-nuklear", 19, 19));
        dialogueClipDb.AddData(new DialogClip($"{dialogueSteinPath}stein-giraffe", 20, 20));

        const string dialoguePlayerPath = "Dialogue/Player/";
        dialogueClipDb.AddData(new DialogClip($"{dialoguePlayerPath}player-schnauze", 3, 3));
        dialogueClipDb.AddData(new DialogClip($"{dialoguePlayerPath}player-hallo-roboter", 4, 4));
        dialogueClipDb.AddData(new DialogClip($"{dialoguePlayerPath}player-erzähl", 5, 5));
        dialogueClipDb.AddData(new DialogClip($"{dialoguePlayerPath}player-sorry", 7, 7));
        dialogueClipDb.AddData(new DialogClip($"{dialoguePlayerPath}player-roboter", 8, 8));
        dialogueClipDb.AddData(new DialogClip($"{dialoguePlayerPath}player-nein", 12, 12));
        dialogueClipDb.AddData(new DialogClip($"{dialoguePlayerPath}player-ja", 13, 13));
        dialogueClipDb.AddData(new DialogClip($"{dialoguePlayerPath}player-witz", 15, 15));
        dialogueClipDb.AddData(new DialogClip($"{dialoguePlayerPath}player-cool", 16, 16));
        dialogueClipDb.AddData(new DialogClip($"{dialoguePlayerPath}player-vergessen", 17, 17));

        
        dialogueClipDb.close();
    }
}
