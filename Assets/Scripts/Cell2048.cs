using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell2048 : MonoBehaviour
{
    [SerializeField] Cell2048 up;
    [SerializeField] Cell2048 down;
    [SerializeField] Cell2048 left;
    [SerializeField] Cell2048 right;

    [SerializeField] GameObject fillPrefab;

    private void OnEnable() {
        GameController2048.slide += OnSlide;
        GameController2048.checkDeath += CheckDeath;
    }

    private void OnDisable() {
        GameController2048.slide -= OnSlide;
        GameController2048.checkDeath -= CheckDeath;
    }
    
    private void OnSlide(string command)
    {
        if(command.Equals("w"))
            slideUp();
        else if(command.Equals("s"))
            slideDown();
        else if(command.Equals("a"))
            slideLeft();
        else if(command.Equals("d"))
            slideRight();
    }
    private void CheckDeath() {
        if(this.up != null){
            if(this.transform.childCount == 0 || this.up.transform.childCount == 0)
                return;
            if(this.up.transform.childCount != 0) {
                String thisValue = this.transform.GetChild(0).GetChild(0).GetComponent<Text>().text;
                String upValue = this.up.transform.GetChild(0).GetChild(0).GetComponent<Text>().text;
                if(thisValue.Equals(upValue))
                    return;
            }   
        }
        if(this.down != null){
            if(this.transform.childCount == 0 || this.down.transform.childCount == 0)
                return;
            if(this.down.transform.childCount != 0) {
                String thisValue = this.transform.GetChild(0).GetChild(0).GetComponent<Text>().text;
                String upValue = this.down.transform.GetChild(0).GetChild(0).GetComponent<Text>().text;
                if(thisValue.Equals(upValue))
                    return;
            }   
        }
        if(this.left != null){
            if(this.transform.childCount == 0 || this.left.transform.childCount == 0)
                return;
            if(this.left.transform.childCount != 0) {
                String thisValue = this.transform.GetChild(0).GetChild(0).GetComponent<Text>().text;
                String upValue = this.left.transform.GetChild(0).GetChild(0).GetComponent<Text>().text;
                if(thisValue.Equals(upValue))
                    return;
            }   
        }
        if(this.right != null){
            if(this.transform.childCount == 0 || this.right.transform.childCount == 0)
                return;
            if(this.right.transform.childCount != 0) {
                String thisValue = this.transform.GetChild(0).GetChild(0).GetComponent<Text>().text;
                String upValue = this.right.transform.GetChild(0).GetChild(0).GetComponent<Text>().text;
                if(thisValue.Equals(upValue))
                    return;
            }   
        }
        Debug.Log(this.name + " is dead.");
        GameController2048.instance.gameOverCheck();
    }
    private void slideUp()
    {
        Cell2048 currentCell = this;
        Cell2048 nextCell = currentCell.up;
        // This cell is filled
        if(SpawnFilled(currentCell)){
            Debug.Log(currentCell.name + " moved up");

            // Not in the top
            if(nextCell != null){

                nextCell.slideUp();

                // Upper Cell is filled also
                if(SpawnFilled(nextCell) && SpawnFilled(currentCell)){
                    tryCombine(nextCell, currentCell);
                }
                else {
                    Debug.Log(nextCell.name + " create a new spawn");
                    GameObject temp = Instantiate(fillPrefab, nextCell.transform);
                    temp.transform.GetChild(0).gameObject.GetComponent<Text>().text 
                        = currentCell.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text;
                    Debug.Log(currentCell.name + " destroyed");
                    DestroyImmediate(currentCell.transform.GetChild(0).gameObject);    
                }

                nextCell.slideUp();
            }
        }
    }
    private void slideDown()
    {
        Cell2048 currentCell = this;
        Cell2048 nextCell = currentCell.down;
        // This cell is filled
        if(SpawnFilled(currentCell)){
            Debug.Log(currentCell.name + " moved down");

            // Not in the top
            if(nextCell != null){

                nextCell.slideDown();

                // Upper Cell is filled also
                if(SpawnFilled(nextCell) && SpawnFilled(currentCell)){
                    tryCombine(nextCell, currentCell);
                }
                else {
                    Debug.Log(nextCell.name + " create a new spawn");
                    GameObject temp = Instantiate(fillPrefab, nextCell.transform);
                    temp.transform.GetChild(0).gameObject.GetComponent<Text>().text 
                        = currentCell.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text;
                    Debug.Log(currentCell.name + " destroyed");
                    DestroyImmediate(currentCell.transform.GetChild(0).gameObject);    
                }

                nextCell.slideDown();

            }
        }
    }
    private void slideLeft()
    {
        Cell2048 currentCell = this;
        Cell2048 nextCell = currentCell.left;
        // This cell is filled
        if(SpawnFilled(currentCell)){
            Debug.Log(currentCell.name + " moved up");

            // Not in the top
            if(nextCell != null){

                nextCell.slideLeft();

                // Upper Cell is filled also
                if(SpawnFilled(nextCell) && SpawnFilled(currentCell)){
                    tryCombine(nextCell, currentCell);
                }
                else {
                    Debug.Log(nextCell.name + " create a new spawn");
                    GameObject temp = Instantiate(fillPrefab, nextCell.transform);
                    temp.transform.GetChild(0).gameObject.GetComponent<Text>().text 
                        = currentCell.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text;
                    Debug.Log(currentCell.name + " destroyed");
                    DestroyImmediate(currentCell.transform.GetChild(0).gameObject);    
                }

                nextCell.slideLeft();

            }
        }
    }
    private void slideRight()
    {
        Cell2048 currentCell = this;
        Cell2048 nextCell = currentCell.right;
        // This cell is filled
        if(SpawnFilled(currentCell)){
            Debug.Log(currentCell.name + " moved up");

            // Not in the top
            if(nextCell != null){

                nextCell.slideRight();

                // Upper Cell is filled also
                if(SpawnFilled(nextCell) && SpawnFilled(currentCell)){
                    tryCombine(nextCell, currentCell);
                }
                else {
                    Debug.Log(nextCell.name + " create a new spawn");
                    GameObject temp = Instantiate(fillPrefab, nextCell.transform);
                    temp.transform.GetChild(0).gameObject.GetComponent<Text>().text 
                        = currentCell.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text;
                    Debug.Log(currentCell.name + " destroyed");
                    DestroyImmediate(currentCell.transform.GetChild(0).gameObject);    
                }

                nextCell.slideRight();

            }
        }
    }
    private bool SpawnFilled(Cell2048 cell){
        return cell.transform.childCount != 0;
    }
    private void tryCombine(Cell2048 combineIn, Cell2048 combineOut){
        Text Celltext_in = combineIn.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
        Text Celltext_out = combineOut.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
        if(Celltext_in.text.Equals(Celltext_out.text)){
            Debug.Log("Combined" + combineOut.name + " to " +combineIn.name);
            Celltext_in.text = (int.Parse(Celltext_out.text) + int.Parse(Celltext_in.text)).ToString();
            DestroyImmediate(combineOut.transform.GetChild(0).gameObject);
        }
    }
}
