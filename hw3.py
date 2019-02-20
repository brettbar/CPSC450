'''
Brett Barinaga and Andrew Flagstead
CPSC 450
HW3 - Code part
2/18/2019
This program finds the optimal answer to the knapsack problem
It takes in a txt file called "hw3_input.txt" which has the following
input values:
    1. Maximum amount of weight that can be held
    2. Number of items to consider
    3. item 0 weight
    4. item 0 cost
    5. item 1 weight
    6. item 1 cost
    7. etc...
    8. item n weight
    9. item n cost
knapsack problem: Given n items of known weights w1,w2...wn and
values v1,v2,...vn, and a knapsack of capactiy W. Find the most
valuable subset of items that fit into the knapsack.
'''
import numpy as np

def main():
    print()
    print("Reading from file...hw3_input.txt")
    print()
    inputs = read_table("hw3_input.txt")
    vals = get_vals(inputs)
    convert_to_numeric(vals)
    values, stats = knapsack_items(vals)

    sack, good_vibes, op_weight, op_cost = knapsack_bf(values, stats[0][0])

    print("Optimal items in the sack:")
    print(sack)
    print('\n')
    print("Indices of said items:")
    for index in good_vibes:
        print(index, end=',')
    print('\n')
    print("Best weight: ", op_weight)
    print("Best value: ", op_cost)



# Returns an array with all item weights and costs
def knapsack_items(table):
    item_weight_cost = []
    iterator = iter(table)
    for i in iterator:
        temp = [i, next(iterator)]
        item_weight_cost.append(temp)
    # item_weight_cost now is a list of 2 element lists,
    # with the each element in the list representing an
    # item, and the elements of the sublists being the
    # corresponding weight and cost for said item
    values = []
    for i in item_weight_cost[1:]:
        values.append(i)
    stats = [item_weight_cost[0]]
    return values, stats

# used this for index part
# https://www.programiz.com/python-programming/methods/list/index
def knapsack_bf(items, capacity):
    sack = []
    op_weight = 0
    op_cost = 0
    good_vibes = []

    for i in range(len(powerset(items))):
        set = powerset(items)[i]
        set_weight = 0
        set_cost = 0
        for j in range(len(set)):
            set_weight += set[j][0]
        for j in range(len(set)):
            set_cost += set[j][1]

        if set_weight <= capacity and op_cost < set_cost:
            op_cost = set_cost
            op_weight = set_weight
            sack = set

    for i in range(len(sack)):
        if sack[i] in items:
            good_vibes.append(items.index(sack[i]))

    return sack, good_vibes, op_weight, op_cost

def powerset(items):
    res = [[]]
    for item in items:
        newset = [r+[item] for r in res]
        res.extend(newset)
    return res

def convert_to_numeric(values):
    # walk through each value in values
    # try to convert it to an int
    for i in range(len(values)):
        try:
            numeric_val = int(values[i])
            # success
            values[i] = numeric_val
        except ValueError:
            print(values[i], " is not a numeric type")

def get_vals(table):
    vals = []
    for i in table:
        vals.append(i[0])
    return vals


def read_table(filename):
    '''
    Reads and creates a table from a file
    Parameter filename: a file
    Returns: table with values from file
    '''
    table = [] # will be nested
    # open the file
    infile = open(filename, "r") # "r" is read file mode\
    # read each line in infile and append it to table as a row (1d list)
    # we could use a library like the csv module
    # we will do it by hand for practice, yay!
    lines = infile.readlines()

    for line in lines:
        # get rid of the newLine character
        line = line.strip() # strips whitespace characters
        # now we want to break line into individual strings
        # using the comma as a delimiter
        values = line.split("\n")
        #convert_to_numeric(values)
        table.append(values) # adds to the end

    infile.close()

    return table # will be nested

if __name__ == "__main__":
    main()
