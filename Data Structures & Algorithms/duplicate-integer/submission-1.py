class Solution:
    def hasDuplicate(self, nums: List[int]) -> bool:
        nb_values = set()
        for value in nums :
            if value in nb_values :
                return True
            else :
                nb_values.add(value)
        return False