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
  - 加入醬料
- **定價**: 40 元

### 豬肉漢堡
- **食材**: 麵包、萵苣、番茄、豬肉、醬料
- **加工**: 
  - 切豬肉、煎豬肉 (5 秒)、煎蛋 (2 秒)
  - 萵苣清洗、萵苣切片
  - 番茄清洗、番茄切片
  - 黃瓜清洗、黃瓜切片
  - 切麵包、組裝
- **定價**: 70 元

### 牛肉漢堡
- **食材**: 麵包、萵苣、黃瓜、牛肉、醬料
- **加工**: 
  - 切牛肉、煎牛肉 (5 秒)、煎蛋 (2 秒)
  - 萵苣清洗、萵苣切片
  - 黃瓜清洗、黃瓜切片
  - 切麵包、組裝
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
