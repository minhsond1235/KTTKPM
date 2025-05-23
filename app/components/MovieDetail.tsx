import React, { useState } from 'react';

function MovieDetail() {
    const [isLoggedIn, setIsLoggedIn] = useState(false); // Kiểm tra trạng thái đăng nhập
    const [comment, setComment] = useState('');

    const handleCommentSubmit = () => {
        if (!isLoggedIn) {
            alert('Bạn cần đăng nhập để bình luận!');
            return;
        }
        // Lưu bình luận vào cơ sở dữ liệu
        // ... mã lưu bình luận ...
    };

    return (
        <div>
            {/* ... thông tin phim ... */}
            {isLoggedIn ? (
                <div>
                    <textarea 
                        value={comment} 
                        onChange={(e) => setComment(e.target.value)} 
                        placeholder="Nhập bình luận của bạn" 
                    />
                    <button onClick={handleCommentSubmit}>Gửi bình luận</button>
                </div>
            ) : (
                <p>Bạn cần đăng nhập để bình luận.</p>
            )}
        </div>
    );
} 