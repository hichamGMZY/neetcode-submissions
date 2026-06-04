class Solution:
    def replaceElements(self, arr: List[int]) -> List[int]:
        max_value = -1
        for i in range(len(arr) -1, 0 - 1, -1) :
            print(i )
            current = arr[i]
            arr[i] = max_value
            max_value = max(max_value, current)
        return arr