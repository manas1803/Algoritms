package com.clueless.binarySearchConcepts;

public class BinarySearchCeilAndFloor {
    public int BinarySearchFindCeil(int[] arr, int low, int high, int target){
        while(low<=high){
            int mid = low + (high-low)/2;
            if(target==arr[mid])
                return mid;
            else if(target>arr[mid])
                low=mid+1;
            else
                high=mid-1;
        }
        return low;
    }
    public int BinarySearchFindFloor(int[] arr, int low, int high, int target){
        while(low<=high){
            int mid = low + (high-low)/2;
            if(target==arr[mid])
                return mid;
            else if(target>arr[mid])
                low=mid+1;
            else
                high=mid-1;
        }
        return high;
    }
}
