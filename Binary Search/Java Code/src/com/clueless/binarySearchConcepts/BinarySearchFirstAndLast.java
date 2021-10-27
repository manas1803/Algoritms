package com.clueless.binarySearchConcepts;

public class BinarySearchFirstAndLast {
    public int FirstOccurenceBinarySearch(int[] arr, int low, int high, int target){
        int result=-1;
        while(low<=high){
            int mid = low + (high-low)/2;
            if(target==arr[mid]){
                result=mid;
                high=mid-1;
            }
            else if(target>arr[mid]){
                low=mid+1;
            }
            else{
                high=mid-1;
            }
        }
        return result;
    }
    public int LastOccurenceBinarySearch(int[] arr, int low, int high, int target){
        int result=-1;
        while(low<=high){
            int mid = low + (high-low)/2;
            if(target==arr[mid]){
                result=mid;
                low=mid+1;
            }
            else if(target>arr[mid]){
                low=mid+1;
            }
            else{
                high=mid-1;
            }
        }
        return result;
    }
}
