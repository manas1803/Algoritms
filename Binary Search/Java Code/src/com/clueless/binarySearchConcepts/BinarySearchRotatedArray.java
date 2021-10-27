package com.clueless.binarySearchConcepts;

public class BinarySearchRotatedArray {
    public int BinarySearchTimesArrayRotated(int[] arr, int low, int high){
        int n = arr.length;
        while(low<=high){
            int mid = low + (high-low)/2;
            int prev = (mid-1+n)%n;
            int next = (mid+1)%n;
            if(arr[mid]<arr[next] && arr[mid]<arr[prev]){
                return mid;
            }
            else if(arr[mid]<arr[high]){
                high=mid-1;
            }
            else{
                low=mid+1;
            }
        }
        return -1;
    }
    public int BinarySearchFindNumberInRotatedArray(int[] arr, int low, int high, int target){
        int index = BinarySearchTimesArrayRotated(arr,low,high);
        BinarySearchBasic bsb = new BinarySearchBasic();
        return Math.max(bsb.IterativeBinarySearch(arr,low,index-1,target),bsb.IterativeBinarySearch(arr,index,high,target));
    }
}
