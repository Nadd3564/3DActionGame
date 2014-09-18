<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core"%>
<%@ taglib prefix="form" uri="http://www.springframework.org/tags/form"%>
<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>アイテム一覧</title>
</head>
<body>
	<h1>アイテム一覧</h1>
	<form:form method="post" action="search">
	アイテム名検索
	<input type="text" name="itemName" />
	<input type="submit" value="検索">
	<a href="create">アイテム登録</a>
	<c:if test="${itemlist != null }">
		<table border="1">
			<tr>
				<th>アイテムID</th>
				<th>名前</th>
				<th>アイテム種別</th>
				<th>ゲーム内価格</th>
				<th>攻撃力</th>
				<th>防御力</th>
				<th>説明文</th>
				<th>登録日</th>
				<th>編集</th>
				<th>削除</th>
			</tr>
			<c:forEach var="item" items="${itemlist }" varStatus="status">
				<tr>
					<td><c:out value="${item.itemId }"></c:out></td>
					<td><c:out value="${item.itemName }"></c:out></td>
					<td><c:out value="${item.itemType }"></c:out></td>
					<td><c:out value="${item.price }"></c:out></td>
					<td><c:out value="${item.attack }"></c:out></td>
					<td><c:out value="${item.defense }"></c:out></td>
					<td><c:out value="${item.description }"></c:out>
					<td><c:out value="${item.updateTime }"></c:out></td>
					<td><a href="update?itemId=${item.itemId }">アイテム編集</a>
					<td><a href="delete?itemId=${item.itemId }">アイテム削除</a>
				</tr>
			</c:forEach>
		</table>
	</c:if>
	</form:form>
</body>
</html>