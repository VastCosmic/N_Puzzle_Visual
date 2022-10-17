# N_Puzzle_Visual

## Ver：1.1

效果图：

![image-20221017175943663](https://vc-image-1313154504.cos.ap-shanghai.myqcloud.com/image/202210171759773.png)

## 路径文件格式：

第一行为初始排序：0 为空Puzzle，每个数字以空格分开，共16个数字（1-16），不可重复。

```
2 12 5 6 1 3 11 4 9 10 0 7 13 14 15 8
```

剩余行为路径，每行为将要移动的Puzzle的编号。

```
11
5
12
3
5
12
6
4
7
8
15
11
12
6
3
2
1
5
6
7
8
12
11
15
```

## 使用方法：

①请先读入路径文件。

②Start，中途无法暂停。

③重复可视化路径前，请先Reload !! 重复可视化路径前，请先Reload !!