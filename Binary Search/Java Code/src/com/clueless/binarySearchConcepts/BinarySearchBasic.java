package com.clueless.binarySearchConcepts;

public class BinarySearchBasic
{
    public int RecursiveBinarySearch(int[] arr,int low, int high,int target){
        if(low<=high){
            int mid=low+(high-low)/2;
            if(arr[mid]==target)
                return mid;
            else if(target>arr[mid])
                return RecursiveBinarySearch(arr,mid+1,high,target);
            else
                return RecursiveBinarySearch(arr,low,high-1,target);
        }
        return -1;
    }
    public int IterativeBinarySearch(int[] arr, int low, int high,int target){
        while(low<=high){
            int mid = low + (high-low)/2;
            if(target==arr[mid])
                return mid;
            else if(target>arr[mid])
                low=mid+1;
            else
                high=mid-1;
        }
        return -1;
    }
    public int ReverseSortedBinarySearch(int[] arr, int low, int high,int target){
        while(low<=high){
            int mid = low + (high-low)/2;
            if(target==arr[mid])
                return mid;
            else if(target>arr[mid])
                high=mid-1;
            else
                low=mid+1;
        }
        return -1;
    }
}
