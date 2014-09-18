<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core"%>
<%@ taglib prefix="form" uri="http://www.springframework.org/tags/form"%>
<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>アイテム編集</title>
</head>
<body>
	<h1>アイテム編集</h1>
	<form:form modelAttribute="item" action="update" method="post">
		<table>
		<form:hidden path="itemId"/>
			<tr>
				<td>名前</td>
				<td><form:input path="itemName" /></td>
			</tr>
			<tr>
				<td>アイテム種別</td>
				<td><form:input path="itemType" /></td>
			</tr>
			<tr>
				<td>ゲーム内価格</td>
				<td><form:input path="price" /></td>
			</tr>
			<tr>
				<td>攻撃力</td>
				<td><form:input path="attack" /></td>
			</tr>
			<tr>
				<td>防御力</td>
				<td><form:input path="defense" /></td>
			</tr>
			<tr>
				<td>説明文</td>
				<td><form:textarea path="description" /></td>
			</tr>
		</table>
		<br>
		<input type="submit" value="登録" />
		<input type="reset" value="リセット" />
		<br>
		<br>
		<a href="item">アイテム一覧画面へ</a>
	</form:form>
</body>
</html>