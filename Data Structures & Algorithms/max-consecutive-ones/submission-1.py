class Solution:
    def findMaxConsecutiveOnes(self, nums: List[int]) -> int:
        cpt = 0
        max_cpt = 0
        for value in nums :
            if value == 1 :
                cpt+=1
            else :
                max_cpt = max(cpt, max_cpt)
                cpt = 0
        return max(cpt, max_cpt)