package com.clueless.binarySearchConcepts;

public class BinarySearchOn2DArray
{
    public int[] BinarySearchOn2DArray(int[][] arr,int m,int n,int target){
        int[] result = new int[2];
        result[0]=-1;
        result[1]=-1;
        int i=0;
        int j=m-1;
        while(i>=0 && i<n && j>=0 && j<m){
            if(arr[i][j]==target){
                result[0]=i;
                result[1]=j;
                break;
            }
            else if(target>arr[i][j])
                i++;
            else
                j--;
        }
        return result;
    }
}
