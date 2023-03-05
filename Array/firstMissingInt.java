import java.util.*; 

public class firstMissingInt {
	public static int firstMissing(int[] arr, int n) {
		// Write your code here.
				
		int firstMissing=1;
		Arrays.sort(arr);
		for(int i=0;i<n;i++)
		{
			if(arr[i]==firstMissing)
			{
			firstMissing+=1;
			}
			else if(arr[i]> firstMissing)
			{
				return firstMissing;
			}
		}
		return firstMissing;
	}
}
