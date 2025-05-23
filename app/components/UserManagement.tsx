import React, { useState, useEffect } from 'react';

function UserManagement() {
    const [users, setUsers] = useState([]);
    
    useEffect(() => {
        // Lấy danh sách người dùng từ API
        // ... mã gọi API để lấy người dùng ...
    }, []);

    const handleRoleChange = (userId, newRole) => {
        // Cập nhật quyền hạn của người dùng
        // ... mã cập nhật quyền hạn ...
    };

    return (
        <div>
            <h1>Quản lý người dùng</h1>
            <table>
                <thead>
                    <tr>
                        <th>Tên</th>
                        <th>Email</th>
                        <th>Quyền hạn</th>
                        <th>Thao tác</th>
                    </tr>
                </thead>
                <tbody>
                    {users.map(user => (
                        <tr key={user.id}>
                            <td>{user.name}</td>
                            <td>{user.email}</td>
                            <td>
                                <select 
                                    value={user.role} 
                                    onChange={(e) => handleRoleChange(user.id, e.target.value)}
                                >
                                    <option value="user">User</option>
                                    <option value="admin">Admin</option>
                                </select>
                            </td>
                            <td>
                                <button onClick={() => handleRoleChange(user.id, user.role)}>Cập nhật</button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
} 