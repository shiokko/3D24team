# 3D Game 24' Team Project 1

## 工具

- Unity: 2022.3.47f1

## 分工

| 項目 | 名字 |
| --- | --- |
| 遊戲機制完善（企劃） | 葉宇瀚 |
| 程式 | 賴芷靚、陳怡然 |
| 美術、UI、Animation | 鄭涵之、梁敏豪 |


# 餐廳經營遊戲

## 遊戲機制

遊戲當中一天的時間為 **5 分鐘**，分為上午、下午和晚上：

- **上午 (前 2 分鐘)**：玩家需要出門蒐集食材。
  - 食材若超過保存期限則會壞掉。
  
- **下午 & 晚上 (後 3 分鐘)**：在餐廳內煮飯賣給客人，賺取金錢。
  
- **每天晚上**：玩家需要支付店租，若無法支付店租則遊戲結束。店租會每天上升。

---

## 食材

| 食材名稱 | 採集位置 | 保存期限 | 採集成本          |
|----------|-----------|-----------|-------------------|
| 萵苣     | 蔬果園    | 1 天      | 1 顆 / 3 秒       |
| 番茄     | 蔬果園    | 3 天      | 1 籃 (5 顆) / 10 秒 |
| 黃瓜     | 蔬果園    | 2 天      | 1 根 / 3 秒       |
| 蛋       | 牧場      | 3 天      | 走來走去撿        |
| 牛肉     | 牧場      | 3 天      | 1 公斤 (5 份) / 15 秒 |
| 豬肉     | 牧場      | 2 天      | 1 公斤 (5 份) / 10 秒 |
| 麵條     | 食品行    | 5 天      | 1 份 / 10 元      |
| 麵包     | 食品行    | 5 天      | 1 條 / 15 元      |
| 醬料     | 食品行    | 5 天      | 1 份 / 3 元       |

---

## 食物與價格

### 沙拉
- **食材**: 萵苣、番茄、黃瓜、醬料
- **加工**: 
  - 萵苣清洗、萵苣切片
  - 番茄清洗、番茄切片
  - 黃瓜清洗、黃瓜切片
  - 按順序加入碗中(萵苣-番茄-黃瓜)
  - 加入醬料
- **定價**: 40 元

### 豬肉漢堡
- **食材**: 麵包、萵苣、番茄、豬肉、醬料
- **加工**: 
  - 切豬肉、煎豬肉 (5 秒)、煎蛋 (2 秒)
  - 萵苣清洗、萵苣切片
  - 番茄清洗、番茄切片
  - 黃瓜清洗、黃瓜切片
  - 切麵包
  - 按照順序組裝(麵包-萵苣-肉-番茄-黃瓜-麵包)(在盤子上)
- **定價**: 70 元

### 牛肉漢堡
- **食材**: 麵包、萵苣、黃瓜、牛肉、醬料
- **加工**: 
  - 切牛肉、煎牛肉 (5 秒)、煎蛋 (2 秒)
  - 萵苣清洗、萵苣切片
  - 黃瓜清洗、黃瓜切片
  - 切麵包
  - 按照順序組裝(麵包-萵苣-肉-番茄-黃瓜-麵包)(在盤子上)
- **定價**: 70 元

### 豬肉麵
- **食材**: 豬肉、麵條、醬料
- **加工**: 
  - 切豬肉、裝水、煮水滾 (5 秒)
  - 加入豬肉、麵條、醬料，煮熟 (10 秒)
- **定價**: 60 元

### 青菜麵
- **食材**: 萵苣、麵條、醬料
- **加工**: 
  - 洗菜、裝水、煮水滾 (5 秒)
  - 加入青菜、麵條、醬料，煮熟 (7 秒)
- **定價**: 50 元

### 牛肉麵
- **食材**: 牛肉、麵條、醬料
- **加工**: 
  - 切牛肉、裝水、煮水滾 (5 秒)
  - 加入牛肉、麵條、醬料，煮熟 (15 秒)
- **定價**: 70 元

---


## 遊戲地圖:

- **蔬果園**: 就在餐廳的後門，上午時玩家會出生在這裡。
- **牧場**: 蔬果園後方，需要走過去。
- **食品行**: 需要搭車過去，花費 10 秒鐘，前往後就無法回到蔬果園以及牧場，須等到時間結束回到餐廳。

---

## 遊戲流程:

- **Scene 1: 上午**
  - 玩家出生在蔬果園，並蒐集材料。
  - 第一回合上午為 3 分鐘，之後的每一天上午為 2 分鐘。
  - 時間到後進入 Scene 2。

- **Scene 2: 下午 & 晚上**
  - 餐廳開業，每次會有兩個人在前台，隨機點餐。
  - 玩家開始製作餐點提供給客人，若沒有材料供應，則可以請客人離開，並需要等待 10 秒後才有下一個客人。
  - 若正常供餐，下一位客人會直接出現。
  - 回合結束計算店租，並進入下一回合。

---

## 遊戲組件 (Code):

- **Scene 1:**
  - 玩家移動以及採集材料。
  - 每個材料的生成。
  - 動物隨機移動以及被殺後產生新的個體。
  - 雞蛋掉落。
  - GameManager 控制時間以及紀錄所採集到的材料數量，並可以繼承給下一個 Scene。
  - 搭車到食品行。
  - 食品購買。

- **Scene 2:**
  - 滑鼠拖曳材料。
  - 洗菜。
  - 煮麵。
  - 加入醬料。
  - 切菜。
  - 材料組裝。
  - gameManager控制金錢以及顧客生成以及點菜
  - 回合結束後的資金統計

---

## 遊戲組件 (美術):

- **Scene 1:**
  - 玩家: 走動，殺豬，採集蔬菜，購買，撿蛋。
  - 牛: 走動動畫。
  - 豬: 走動動畫。
  - 雞: 走動&生蛋。
  - 公車。
  - 高麗菜，黃瓜，番茄。
  - 背景: 農場，牧場，食品行。
  - 材料統計 UI 介面。
  - 切換場景以及回合的動畫 (太陽出來以及落下的動畫)。

- **Scene 2:**
  - 餐廳背景。
  - 顧客 (圖片即可，大概 4-5 個)。
  - 食材圖片 (萵苣、番茄、黃瓜需要有洗乾淨以及未清洗的圖片，肉需要有生的，生的切片，煎熟後的)。
  - 切片食材圖片。
  - 刀子、空碗、煎鍋、空鍋、砧板。
  - 水龍頭以及水流。
  - 沙拉 (加入每種材料都要一張圖)。
  - 漢堡 (加入每一層食材都要一張圖)。
  - 麵 (加入水的鍋子，加入材料的鍋子，煮滾的麵的鍋子-兩張圖片的動畫，用碗裝的麵)。
  - 在顧客點餐介面下要有餐點的名子。
  - 食物製作方法的介紹 UI。
  - 付房租以及統計錢的 UI。
    
---

## 遊戲操作:
- **Scene 1:**
  - 玩家WASD移動
  - 靠近植物時按下左鍵採集
  - 靠近動物時按下左鍵擊殺
  - 靠近公車按下左鍵上車
  - 進到商店介面點擊食材購買

- **Scene 2:**
  - 長按滑鼠左鍵拖曳食材以及工具
  - 放置食材在砧板上拖曳刀子過去可以切採
  - 拖曳食材到水龍頭放開可以洗菜
  - 拖曳食材到盤子或腕上可以組裝對應的食物
  - 食材拖曳到鍋子內可以放入鍋子
  - 鍋子拖到灶台可以煮
  - 若食材等等不完整會取消上菜或是煮飯或是組裝的操作

