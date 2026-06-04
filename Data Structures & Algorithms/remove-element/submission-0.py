class Solution:
    def removeElement(self, nums: List[int], val: int) -> int:
        swap_index = 0
        for element in nums :
            if element == val :
                continue
            else :
                nums[swap_index] = element
                swap_index += 1

        return swap_index
