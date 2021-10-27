import com.clueless.binarySearchConcepts.*;

public class App {
    public static void main(String[] args) {
        int target = 57;

        int[] arr= {2,8,9,12,18,25,31,57,57,57,57,57,57,57,57,57,98};
        int[] rotatedArray = {18,25,31,57,98,2,8,9,12};
        int[] reverseArray = {98,57,31,25,18,12,9,8,2};
        int[] ceilFloor = {12,15,24,37,41,45,48,51,52,71,98,101};
        int[][] matrixArray = {{2,6,9},{3,7,10},{6,8,12}};

        BinarySearchBasic bsb = new BinarySearchBasic();
        BinarySearchFirstAndLast bfl = new BinarySearchFirstAndLast();
        BinarySearchRotatedArray bsr = new BinarySearchRotatedArray();
        BinarySearchCeilAndFloor bsc = new BinarySearchCeilAndFloor();
        BinarySearchOn2DArray bs2 = new BinarySearchOn2DArray();

        System.out.println("Iterative result is "+bsb.IterativeBinarySearch(arr,0,arr.length-1,target));
        System.out.println("Recursive result is "+bsb.RecursiveBinarySearch(arr,0,arr.length-1,target));
        System.out.println("Reverse result is "+bsb.ReverseSortedBinarySearch(reverseArray,0,arr.length-1,target));
        System.out.println("First Occurrence result is "+bfl.FirstOccurenceBinarySearch(arr,0,arr.length-1,target));
        System.out.println("Last Occurrence result is "+bfl.LastOccurenceBinarySearch(arr,0,arr.length-1,target));
        System.out.println("Rotation Times  result is "+bsr.BinarySearchTimesArrayRotated(rotatedArray,0,rotatedArray.length-1));
        System.out.println("Number in rotated result is "+bsr.BinarySearchFindNumberInRotatedArray(rotatedArray,0,rotatedArray.length-1,target));
        System.out.println("Floor of the number target is "+ceilFloor[bsc.BinarySearchFindFloor(ceilFloor,0,ceilFloor.length-1,target)]);
        System.out.println("Ceil of the number target is "+ceilFloor[bsc.BinarySearchFindCeil(ceilFloor,0,ceilFloor.length-1,target)]);
        System.out.println("Result for matrix array is "+bs2.BinarySearchOn2DArray(matrixArray,3,3,7)[0] + " ," + bs2.BinarySearchOn2DArray(matrixArray,3,3,7)[1]);
    }
}
