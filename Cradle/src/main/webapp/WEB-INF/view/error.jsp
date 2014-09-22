<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core"%>
<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>エラーページ</title>
</head>
<body>
<h1>この画面にアクセスする権限がありません</h1>
<a href="/Cradle/item">アイテム画面に戻る</a><br><br>
<a href="<c:url value="/j_spring_security_logout" />">Logout</a>

</body>
</html>