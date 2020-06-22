using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CosmeticDashboard.Models
{
    public class Note
    {
        /// <summary>
        /// 게시물 번호
        /// </summary>
        [Key]
        public int NoteNo { get; set; }

        /// <summary>
        /// 게시물 제목
        /// </summary>
        [Required(ErrorMessage ="제목을 입력해주세요.")]
        public string NoteTitle { get; set; }

        /// <summary>
        /// 게시물 내용
        /// </summary>
        [Required(ErrorMessage = "내용을 입력해주세요.")]
        public string NoteContents { get; set; }

        /// <summary>
        /// 게시물 작성일
        /// </summary>
        [Required]
        public string NoteDate { get; set; }


        /// <summary>
        /// 작성자 번호
        /// </summary>
        [Required]
        public int UserNo { get; set; }


        [ForeignKey("UserNo")]
        public virtual User User { get; set; }  // virtual -> lazy 로딩이라고 해서 주데이터를 
                                                // 먼저 출력을하고 나중에 천천히 비동기적으로 가져오는 방법:
                                                // Entity Framework 자체상 외래키(현 테이블 외에 다른 테이블을 가져올때는 
                                                // virtual 선언을 해주는것을 권장한다.
    }
}
